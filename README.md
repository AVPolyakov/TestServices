# Подмена сервисов в тестах

Сервис можно заменить в тестах с помощью статического метода `SetCurrent`:

```csharp
ISampleService service = ...
Service.SetCurrent(service)
```

Подключение в DI контейнер происходит с помощью метода `DecorateByTestServices`.

## Пример использования

```csharp
[Fact]
public async Task GetSampleValue_WhenCalledWithMock_ReturnsMockValue()
{
    Service.SetCurrent(Substitute.For<ISampleService>())
        .GetSampleValue().ReturnsForAnyArgs("Mock value");
    
    var sampleController = RestClient.For<ISampleController>(_factory.HttpClient);
    
    var sampleValue = await sampleController.GetSampleValue();
    Assert.Equal("Mock value", sampleValue);
}
```