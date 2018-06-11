# Kentico Cloud Personal Data .NET SDK

[![Build status](https://ci.appveyor.com/api/projects/status/as11gvayj6vm087l?svg=true)](https://ci.appveyor.com/project/kentico/personal-data-sdk-net)
[![NuGet](https://img.shields.io/nuget/v/KenticoCloud.PersonalData.svg)](https://www.nuget.org/packages/KenticoCloud.PersonalData)
[![Forums](https://img.shields.io/badge/chat-on%20forums-orange.svg)](https://forums.kenticocloud.com)
[![Analytics](https://ga-beacon.appspot.com/UA-69014260-4/Kentico/personal-data-sdk-net?pixel)](https://github.com/igrigorik/ga-beacon)

## Summary

The Kentico Cloud Personal Data .NET SDK is a client library used for retrieving or deleting data about your tracked visitors. You can use the SDK in the form of a [NuGet package](https://www.nuget.org/packages/KenticoCloud.PersonalData).

## Prerequisites

To retrieve and delete data from Kentico Cloud via the [Personal Data API](https://developer.kenticocloud.com/reference#personal-data-api), you need to have a Kentico Cloud subscription at <https://app.kenticocloud.com>. For more information see our [documentation](http://help.kenticocloud.com/).

### Getting User ID

Some methods of the SDK work with User ID, which identifies a specific visitor on your website. You can get this value either by parsing the content of a cookie using the [Personalization SDK](https://github.com/Kentico/personalization-sdk-net#getting-userid-and-sessionid) or by calling a JavaScript method in the code of your website. For more details, see [Identifying visitors on websites](https://developer.kenticocloud.com/docs/retrieving-user-and-session-id).

## Using the PersonalDataClient

The `PersonalDataClient` class is the main class of the SDK. Using this class, you can retrieve and delete visitor data stored in your Kentico Cloud project.

To create an instance of the class, you need to provide a **Project ID** and your **Personal Data API Key**. You can find both inside the [Kentico Cloud app](https://app.kenticocloud.com/). From the app menu, choose *Project settings*. Then, under Development, choose *API keys*.

```csharp
var projectId = new Guid("<YOUR_PROJECT_ID");
var apiKey = "<YOUR_PERSONAL_DATA_API_KEY>";

client = new PersonalDataClient(apiKey, projectId);
```

### Retrieving personal data of tracked visitors

All data about the specified visitor stored in Kentico Cloud is returned as a JSON string.

#### Getting data by email address

```csharp
var response = await client.GetByEmailAsync("kroberts2y@godaddy.com");
```

#### Getting data by User ID

```csharp
var response = await client.GetByUidAsync("1a7379c4026d4614");
```

### Deleting personal data of tracked visitors

Calling a delete method registers a deletion request on our servers. All personal data of the specified visitor is then deleted within 24 hours.

#### Deleting data by email address

```csharp
client.DeleteByEmailAsync("kroberts2y@godaddy.com");
```

#### Deleting data by User ID

```csharp
client.DeleteByUidAsync("1a7379c4026d4614");
```

## Feedback & Contributing
Check out the [contributing](https://github.com/Kentico/personal-data-sdk-net/blob/master/CONTRIBUTING.md) page to see the best places to file issues, start discussions and begin contributing.
