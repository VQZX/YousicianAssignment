using System;
using System.Collections;
using OrbCreationExtensions;
using UnityEngine;

namespace YousicianAssignment.Interface
{
    public class ProgramInfo
    {
        public string ItemTitle { get; protected set; }
        
        public string Description { get; protected set; }
        public ArrayList CountryOfOrigin { get; protected set; }
        public ArrayList Creator { get; protected set; }
        
        public string Subject { get; protected set; }
        
        public string Type { get; protected set; }

        private Hashtable table;
        
        public ProgramInfo(Hashtable table)
        {
            this.table = table;
            
            // Assign
            ItemTitle = (string)((Hashtable)this.table["title"])["fi"];
            Description = (string)((Hashtable)this.table["description"])["fi"];
            CountryOfOrigin = (ArrayList) (this.table["countryOfOrigin"]);
            Creator = (ArrayList) (this.table["creator"]);
            ArrayList subjects = (ArrayList) this.table["subject"];
            foreach (var subject in subjects)
            {
                Hashtable hash = (Hashtable) subject;
                if (hash.ContainsKey("key"))
                {
                    Subject = (string)hash["key"];
                    Type = (string) hash["type"];
                    break;
                }
            }
        }

        public override string ToString()
        {
            string output = ItemTitle + "\n";
            output += "Country of Origin: ";
            foreach (var country in CountryOfOrigin)
            {
                output += country + " ";
            }

            output += "Creator: ";
            foreach (var creator in Creator)
            {
                output += creator + " ";
            }

            output += "\n" + Description + "\n";

            output += Subject + "\n";

            output += Type + "\n";

            return output;
        }
    }
}