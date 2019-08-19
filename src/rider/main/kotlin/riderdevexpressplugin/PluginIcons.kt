package riderdevexpressplugin

import com.intellij.openapi.util.IconLoader
import icons.RiderIcons
import javax.swing.Icon

class PluginIcons {
    companion object{
        fun findTemplateIcon(): Icon {
            val path = this::class.java.classLoader.getResource("/icons/devexpressicon.png")
            return IconLoader.findIcon(path) ?: RiderIcons.Template.TemplateProject
        }
    }
}