using SpaceApp.Dev.ApiToMobile.Attributes;

namespace Myffin.API.Responses
{
    [GenericArgumentsNotNull]
    public class ResponseWrapper<TData>
    {
        public OperationStatus OperationStatus { get; set; }

        public TData? ResponseData { get; set; }

        public ResponseWrapper(OperationStatus operationStatus)
        {
            OperationStatus = operationStatus;
        }
    }
}