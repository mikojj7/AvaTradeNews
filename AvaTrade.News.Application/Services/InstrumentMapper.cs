namespace AvaTrade.News.Application.Services;

public interface IInstrumentMapper
{
    string GetInstrumentName(string content);
    
}

public class InstrumentMapper : IInstrumentMapper
{
    public string GetInstrumentName(string content)
    {
        //provide some logic to get the instrument name from article title or content
        return "Commodities";
    }
}

