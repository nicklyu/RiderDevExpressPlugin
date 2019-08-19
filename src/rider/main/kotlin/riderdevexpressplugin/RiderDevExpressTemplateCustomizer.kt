package riderdevexpressplugin

import com.jetbrains.rider.projectView.actions.projectTemplating.backend.ReSharperProjectTemplateCustomizer

class RiderDevExpressTemplateCustomizer : ReSharperProjectTemplateCustomizer {
    override val categoryName = "DevExpress"
    override val newIcon = PluginIcons.findTemplateIcon()
    override val newName = "DevExpress"
}