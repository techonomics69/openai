﻿using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.Models;
using OpenAI.GPT3.Models.RequestModels;

namespace OpenAI.Playground.TestHelpers
{
    internal static class ClassificationsTestHelper
    {
        public static async Task RunSimpleClassificationTest(IOpenAIService sdk)
        {
            ConsoleExtensions.WriteLine("Run Simple Classification Test is starting:", ConsoleColor.Cyan);

            try
            {
                var classificationResponse = await sdk.Classifications.ClassificationsCreate(new ClassificationCreateRequest()
                {
                    Examples = new List<List<string>>()
                    {
                        new()
                        {
                            "A happy moment", "Positive"
                        },
                        new()
                        {
                            "I am sad.", "Negative"
                        },
                        new()
                        {
                            "I am feeling awesome", "Positive"
                        }
                    },
                    SearchModel = Engines.Engine.Ada.EnumToString(),
                    Model = Engines.Engine.Curie.EnumToString(),
                    Query = "It is a raining day :(",
                    Labels = new List<string>()
                    {
                        "Positive", "Negative", "Neutral"
                    }
                });

                Console.WriteLine(classificationResponse.Label);
            }
            catch (Exception e)
            {
                ConsoleExtensions.WriteLine(e.Message, ConsoleColor.Red);
                throw;
            }
        }
    }
}