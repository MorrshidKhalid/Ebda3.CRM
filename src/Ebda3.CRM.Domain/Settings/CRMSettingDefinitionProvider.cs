﻿using Volo.Abp.Settings;

namespace Ebda3.CRM.Settings;

public class CRMSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(CRMSettings.MySetting1));
    }
}
