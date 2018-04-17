﻿using System;
using System.IO;
using Newtonsoft.Json;

namespace RetroClash
{
    public class Configuration
    {
        [JsonIgnore]
        public const int Users = 1000;

        [JsonIgnore]
        public const int BufferSize = 2048;

        [JsonIgnore]
        public static bool Debug = false;

        [JsonIgnore]
        public static bool Maintenance = false;

        [JsonProperty("encryption_key")] public string EncryptionKey = "fhsd6f86f67rt8fw78fw789we78r9789wer6re";

        [JsonProperty("update_url")] public string UpdateUrl = "https://retroclash.pw/";

        [JsonProperty("patch_url")] public string PatchUrl = "";

        [JsonProperty("mysql_user")] public string MySqlUserId = "root";

        [JsonProperty("mysql_server")] public string MySqlServer = "127.0.0.1";

        [JsonProperty("mysql_password")] public string MySqlPassword = "";

        [JsonProperty("mysql_database")] public string MySqlDatabase = "rcdb";

        [JsonProperty("redis_password")] public string RedisPassword = "";

        [JsonProperty("redis_server")] public string RedisServer = "127.0.0.1";


        public void Initialize()
        {
            if (File.Exists("config.json"))
                try
                {
                    var config = JsonConvert.DeserializeObject<Configuration>(File.ReadAllText("config.json"));

                    UpdateUrl = config.UpdateUrl;
                    PatchUrl = config.PatchUrl;
                    MySqlUserId = config.MySqlUserId;
                    MySqlServer = config.MySqlServer;
                    MySqlPassword = config.MySqlPassword;
                    MySqlDatabase = config.MySqlDatabase;
                    RedisPassword = config.RedisPassword;
                    RedisServer = config.RedisServer;
                    EncryptionKey = config.EncryptionKey;
                }
                catch (Exception)
                {
                    Console.WriteLine("Couldn't load configuration.");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            else
                try
                {
                    File.WriteAllText("config.json", JsonConvert.SerializeObject(this, Formatting.Indented));

                    Console.WriteLine("New configuration has been created. Restart server.");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                catch (Exception)
                {
                    Console.WriteLine("Couldn't create config file.");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
        }

    }
}