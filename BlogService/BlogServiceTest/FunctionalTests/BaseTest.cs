namespace BlogServiceTest.FunctionalTests; 

public abstract class BaseTest {
    private readonly CustomWebApiFactory _factory;

    protected BaseTest(CustomWebApiFactory factory) {
        _factory = factory;
    }
    // private readonly CustomWebApiFactory _factory;
    
    // protected BaseTest(CustomWebApiFactory factory) {
    //     this._factory = factory;
    // }

    protected CustomWebApiFactory Factory => _factory;
    protected HttpClient Client => _factory.CreateClient();
}