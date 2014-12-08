namespace StringAppearances
{    
    using System.ServiceModel;

    [ServiceContract]
    public interface IStringAppearancesService
    {
        [OperationContract]
        int CountAppearances(string searched, string text);
    }
}
