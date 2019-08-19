package riderdevexpressplugin

import com.jetbrains.rdclient.util.idea.LifetimedApplicationComponent
import com.jetbrains.rider.model.RiderDevExpressPluginModel

class PluginResourcesPathProvider : LifetimedApplicationComponent() {

    private val Logger = com.intellij.openapi.diagnostic.Logger.getInstance("DevExpressPathProvider")

    init {
        val resourcePath = this.javaClass.classLoader.getResources("templates").nextElement()

        if(resourcePath == null){
            Logger.error("Resource path is unavailable")
        }

        val model = RiderDevExpressPluginModel()
        model.pluginTemplatesPath.set(resourcePath!!.path)
    }
}