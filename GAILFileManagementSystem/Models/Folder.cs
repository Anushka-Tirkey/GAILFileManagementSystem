// Folder.cs
using System;

namespace GAILFileManagementSystem.Models
{
    public class Folder
    {
        // Properties
        public int FolderId { get; set; } // Unique identifier for the folder
        public string FolderName { get; set; } // Name of the folder
        public int? ParentFolderId { get; set; } // ID of the parent folder if folders are organized hierarchically

        // Constructor
        public Folder()
        {
            // Initialize properties with default values if needed
            FolderId = 0;
            FolderName = "";
            ParentFolderId = null;
        }
    }
}
