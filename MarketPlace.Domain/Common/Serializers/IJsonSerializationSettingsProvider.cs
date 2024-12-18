﻿using Newtonsoft.Json;

namespace MarketPlace.Domain.Common.Serializers;

public interface IJsonSerializationSettingsProvider
{
    JsonSerializerSettings Configure(JsonSerializerSettings settings);

    JsonSerializerSettings ConfigureForEventBus(JsonSerializerSettings settings);


    JsonSerializerSettings Get(bool clone = false);

    JsonSerializerSettings GetForEventBus(bool clone = false);
}