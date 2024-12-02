using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

class DataLoader
{
    public static List<Biome> LoadBiomes(string filePath)
    {
        string json = File.ReadAllText(filePath);
        var roomData = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(json);

        var biomes = new Dictionary<string, Biome>();

        foreach (var roomEntry in roomData.Values)
        {
            string biomeName = roomEntry["Biome"];
            if (!biomes.ContainsKey(biomeName))
            {
                biomes[biomeName] = new Biome(biomeName);
            }

            // Extract Room Data
            string roomName = roomEntry["Name"];
            string roomDescription = roomEntry["Description"];
            var quest = ParseQuest(roomEntry["Quest"]);
            var npc = ParseNpc(roomEntry["Npc"]);

            var room = new Room(roomName, roomDescription, quest, npc);
            biomes[biomeName].AddRoom(room);
        }

        return new List<Biome>(biomes.Values);
    }

    private static Quest ParseQuest(dynamic questData)
    {
        string questionPrompt = questData["QuestionPromt"];
        var choices = new Dictionary<string, QuestChoice>();

        foreach (var choiceKey in questData["Choices"])
        {
            string key = choiceKey.Name;
            string choiceText = questData["Choices"][key]["Choice"];
            bool isCorrect = questData["Choices"][key]["Correct"];

            choices[key] = new QuestChoice(choiceText, isCorrect);
        }

        return new Quest(questionPrompt, choices);
    }

    private static Npc ParseNpc(dynamic npcData)
    {
        string name = npcData["Name"];
        string dialogue = npcData["Dialogue"];

        return new Npc(name, dialogue);
    }
}
