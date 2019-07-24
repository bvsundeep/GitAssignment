using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace POPS_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        SUPPLIER GetSupplier(string id);

        [OperationContract]
        IEnumerable<SUPPLIER> GetAllSuppliers();

        [OperationContract]
        void AddSupplier(SUPPLIER item);

        [OperationContract]
        void UpdateSupplier(SUPPLIER item);

        [OperationContract]
        void DeleteSupplier(string id);
    }
}
