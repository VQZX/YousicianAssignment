using System;
using System.Collections;
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
            Subject = (string) ((Hashtable) this.table["subject"])["key"];
            Type = (string) ((Hashtable) this.table["subject"])["type"];
        }
    }
}