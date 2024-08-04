using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace VkLib.Core.Attachments
{
    public class VkAttachment
    {
        public long Id { get; set; }

        public long Owner_Id { get; set; }

        public virtual string Type { get; set; }

        public override string ToString()
        {
            return string.Format("{0}{1}_{2}", Type, Owner_Id, Id);
        }

        public static List<VkAttachment> FromJson(JToken json)
        {
            var result = new List<VkAttachment>();

            foreach (var a in json)
            {
                switch (a["type"].Value<string>())
                {
                    case "audio":
                        result.Add(VkAudioAttachment.FromJson(a["audio"]));
                        break;

                    case "photo":
                        result.Add(VkPhotoAttachment.FromJson(a["photo"]));
                        break;
                }
            }

            return result;
        }
    }
}
