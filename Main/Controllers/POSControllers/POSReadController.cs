using AutoMapper;
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
        private readonly OtherSettings _otherSettings;

        public POSReadController(ILogger<POSReadController> logger,
                                IMapper mapper,
                                ISaleTransactionData salesTransactionData,
                                IOptions<OtherSettings> otherSettings)
        {
            _logger = logger;
            _mapper = mapper;
            _salesTransactionData = salesTransactionData;
            _otherSettings = otherSettings.Value;
        }

        public List<SaleTransactionModel> GetActiveDineInSalesTransaction()
        {
            var activeDineInSalesTrans = _salesTransactionData.GetSalesTransactionByStatusAndTransType(StaticData.POSTransactionStatus.OnGoing, StaticData.POSTransactionType.DineIn);
            return activeDineInSalesTrans;
        }


        public List<TableStatusModel> GetTableStatus()
        {
            int numberOfTable = _otherSettings.POSNumberOfTable;
            List<TableStatusModel> tables = new List<TableStatusModel>();

            var activeDineInSalesTrans = this.GetActiveDineInSalesTransaction();

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
    }
}
