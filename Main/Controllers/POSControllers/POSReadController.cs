﻿using AutoMapper;
using DataAccess.Data.POSManagement.Contracts;
using EntitiesShared.POSManagement.CustomModels;
using Main.Controllers.POSControllers.ControllerInterface;
using Microsoft.Extensions.Logging;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesShared;
using EntitiesShared.POSManagement;
using Microsoft.Extensions.Options;

namespace Main.Controllers.POSControllers
{
    public class POSReadController : IPOSReadController
    {
        private readonly ILogger<POSReadController> _logger;
        private readonly IMapper _mapper;
        private readonly ISaleTransactionData _salesTransactionData;
        private readonly ISaleTransactionProductData _saleTransactionProductData;
        private readonly ISaleTransactionComboMealData _saleTransactionComboMealData;
        private readonly OtherSettings _otherSettings;

        public POSReadController(ILogger<POSReadController> logger,
                                IMapper mapper,
                                ISaleTransactionData salesTransactionData,
                                ISaleTransactionProductData saleTransactionProductData,
                                ISaleTransactionComboMealData saleTransactionComboMealData,
                                IOptions<OtherSettings> otherSettings)
        {
            _logger = logger;
            _mapper = mapper;
            _salesTransactionData = salesTransactionData;
            _saleTransactionProductData = saleTransactionProductData;
            _saleTransactionComboMealData = saleTransactionComboMealData;
            _otherSettings = otherSettings.Value;
        }

        public List<SaleTransactionModel> GetActiveDineInSalesTransactions()
        {
            var activeDineInSalesTrans = _salesTransactionData.GetSalesTransactionByStatusAndTransType(StaticData.POSTransactionStatus.OnGoing, StaticData.POSTransactionType.DineIn);
            return activeDineInSalesTrans;
        }

        public List<SaleTransactionModel> GetActiveSalesTransactions()
        {
            var activeDineInSalesTrans = _salesTransactionData.GetSalesTransactionByStatus(StaticData.POSTransactionStatus.OnGoing);
            return activeDineInSalesTrans;
        }

        public List<TableStatusModel> GetTableStatus()
        {
            int numberOfTable = _otherSettings.POSNumberOfTable;
            List<TableStatusModel> tables = new List<TableStatusModel>();

            var activeDineInSalesTrans = this.GetActiveDineInSalesTransactions();

            for(var tableNum=1; tableNum <= numberOfTable; tableNum++)
            {
                var activeDineInOnTheCurrentTable = activeDineInSalesTrans.Where(x => x.TableNumber == tableNum).FirstOrDefault();

                tables.Add(new TableStatusModel { 
                    TableNumber = tableNum,
                    TableTitle = $"T-{tableNum}",
                    Status = activeDineInOnTheCurrentTable == null ? StaticData.TableStatus.Available : StaticData.TableStatus.Occupied
                });
            }

            return tables;
        }


        public IEnumerable<SaleTransactionProductModel> GetSaleTranProducts (long saleTransactionId)
        {
            return _saleTransactionProductData.GetAllBySaleTransId(saleTransactionId);
        }

        public IEnumerable<SaleTransactionComboMealModel> GetSaleTranComboMeals(long saleTransactionId)
        {
            return _saleTransactionComboMealData.GetAllBySaleTranId(saleTransactionId);
        }

    }
}