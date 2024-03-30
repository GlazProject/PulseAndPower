using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Models
{
  
          /// <summary>
          /// Gets or Sets TimeOfDay
          /// </summary>
          [JsonConverter(typeof(JsonStringEnumConverter))]
          public enum TimeOfDay
          {
              /// <summary>
              /// Enum Enum for Утренние
              /// </summary>
              [EnumMember(Value = "Утренние")]
              Enum = 0,
              /// <summary>
              /// Enum Enum for Весь день
              /// </summary>
              [EnumMember(Value = "Весь день")]
              Enum = 1,
              /// <summary>
              /// Enum Enum for Вечерние
              /// </summary>
              [EnumMember(Value = "Вечерние")]
              Enum = 2          }
}
