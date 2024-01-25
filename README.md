# Подмена сервисов с помощью статического метода

Сервис можно заменить в тестах с помощью статического метода `SetCurrent`:

```csharp
ISampleService service = ...
Service.SetCurrent(service)
```

Если current равно `null`, то используется сервис, ранее зарегистрированный в DI контейнере.

Подключение в DI контейнер происходит с помощью метода `DecorateByTestServices`.

Текущее значение current сохраняется в AsyncLocal. Поэтому область действия текущего значения совпадает с областью действия значения в AsyncLocal.

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