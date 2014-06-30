using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using DiaryWcfService.Classes;

namespace DiaryWcfService
{
    [ServiceContract]
    public interface IUserService
    {

        [OperationContract]
        [WebGet(UriTemplate = "/User/{data}", ResponseFormat = WebMessageFormat.Json)]
        ReturnPackage<List<DailyNotes>> GetDailyData(string data);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/User", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        ReturnPackage<User> SetDailyData();
    }

    public class UserService : IUserService
    {
        private const string API_DESCRIPTION = "Сервис для работы с пользователями";

        public ReturnPackage<User> SetDailyData()
        {
            return ReturnPackage<User>.GeneratePackage(API_DESCRIPTION, null, PackageStatus.INTERNAL_ERROR);
        }

        public ReturnPackage<List<DailyNotes>> GetDailyData(string data)
        {
            List<DailyNotes> dailyList;
            using (var context = new DiaryDatabaseEntities())
            {
                var user = context.User.First();
                dailyList = context.DailyNotes.Where(u=>u.User == user).ToList();
            }
            return ReturnPackage<List<DailyNotes>>.GeneratePackage(API_DESCRIPTION, dailyList, PackageStatus.OK);
        }
    }
}
