﻿using Pavolle.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pavolle.CrudOperationHelper.Business.DbModels
{
    public class BaseObjectCreatorManager : Singleton<BaseObjectCreatorManager>, ICreatorManager
    {
        DbModelCreatorManager creator;

        private BaseObjectCreatorManager()
        {

        }

        public bool Write(string companyName, string projectName, string projectPath)
        {
            string projectNameRoot = companyName + "." + projectName;
            string baseObjectClass = "";
            baseObjectClass += "using DevExpress.Xpo;" + Environment.NewLine;
            baseObjectClass += "using System;" + Environment.NewLine;
            baseObjectClass += "using System.Collections.Generic;" + Environment.NewLine;
            baseObjectClass += "using System.Linq;" + Environment.NewLine;
            baseObjectClass += "using System.Text;" + Environment.NewLine;
            baseObjectClass += "using System.Threading.Tasks;" + Environment.NewLine;
            baseObjectClass += "" + Environment.NewLine;
            baseObjectClass += "namespace " + projectNameRoot + "." + AppConsts.DBModelsProjectName + "." + AppConsts.DBModelsEntitiesFolderName + Environment.NewLine;
            baseObjectClass += "{" + Environment.NewLine;
            baseObjectClass += "    [NonPersistent]" + Environment.NewLine;
            baseObjectClass += "    public class " + AppConsts.DBModelsBaseObjectClassName + " : XPBaseObject" + Environment.NewLine;
            baseObjectClass += "    {" + Environment.NewLine;
            baseObjectClass += "" + Environment.NewLine;
            baseObjectClass += "        public " + AppConsts.DBModelsBaseObjectClassName + "(Session session) : base(session)" + Environment.NewLine;
            baseObjectClass += "        {" + Environment.NewLine;
            baseObjectClass += "" + Environment.NewLine;
            baseObjectClass += "        }" + Environment.NewLine;
            baseObjectClass += "" + Environment.NewLine;
            baseObjectClass += "        public override void AfterConstruction()" + Environment.NewLine;
            baseObjectClass += "        {" + Environment.NewLine;
            baseObjectClass += "            base.AfterConstruction();" + Environment.NewLine;
            baseObjectClass += "            CreatedTime = DateTime.Now;" + Environment.NewLine;
            baseObjectClass += "        }" + Environment.NewLine;
            baseObjectClass += "" + Environment.NewLine;
            baseObjectClass += "        [Persistent(\"oid\")]" + Environment.NewLine;
            baseObjectClass += "        [Key(true)]" + Environment.NewLine;
            baseObjectClass += "        public long Oid { get; set; }" + Environment.NewLine;
            baseObjectClass += "" + Environment.NewLine;
            baseObjectClass += "        [Persistent(\"created_time\")]" + Environment.NewLine;
            baseObjectClass += "        public DateTime CreatedTime { get; set; }" + Environment.NewLine;
            baseObjectClass += "" + Environment.NewLine;
            baseObjectClass += "        [Persistent(\"last_update_time\")]" + Environment.NewLine;
            baseObjectClass += "        public DateTime? LastUpdateTime { get; set; }" + Environment.NewLine;
            baseObjectClass += "    }" + Environment.NewLine;
            baseObjectClass += "}" + Environment.NewLine;

            return FileHelperManager.Instance.WriteFile(projectPath, projectNameRoot + "." + AppConsts.DBModelsProjectName + "/" + AppConsts.DBModelsEntitiesFolderName, AppConsts.DBModelsBaseObjectClassFileName, baseObjectClass);
        }
    }
}
