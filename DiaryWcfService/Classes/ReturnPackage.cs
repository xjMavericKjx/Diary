using System.Runtime.Serialization;

namespace DiaryWcfService.Classes
{
    public enum PackageStatus
    {
        OK = 200,
        BAD_REQUEST = 400,
        UNAUTHORIZED = 401,
        FORBIDDEN = 403,
        NOT_FOUND = 404,
        INTERNAL_ERROR = 500,
        NOT_IMPLEMENTED = 501
    }

    [DataContract]
    public class ReturnPackage<T> //Пакет возвращаемых данных, T - тип возвращаемых данных функцией сервиса
    {
        [DataMember(Order = 0)]
        public string ApiVersion;

        [DataMember(Order = 1)]
        public PackageStatus Status; // Код возвращаемого сообщения (200, 404 и тд)

        [DataMember(Order = 2)]
        public string ApiDescription;

        [DataMember(Order = 3)]
        public T Data; // Возвращаемые данные

        public static ReturnPackage<T> GeneratePackage(string apiDescripton, T data, PackageStatus status)
        {
            var package = new ReturnPackage<T>
            {
                ApiVersion = ApiHelper.GetApiVersion(),
                ApiDescription = apiDescripton,
                Data = data,
                Status = status
            };

            return package;
        }
    }
}