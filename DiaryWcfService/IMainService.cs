using System.ServiceModel;
using System.ServiceModel.Web;

namespace DiaryWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMainService" in both code and config file together.
    [ServiceContract]
    public interface IMainService
    {
        [OperationContract]
        [WebInvoke(Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "/Organisation", BodyStyle = WebMessageBodyStyle.Wrapped)]
        void DoWork();
    }
}
