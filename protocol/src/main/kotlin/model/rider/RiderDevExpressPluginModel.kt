package model.rider

import com.jetbrains.rd.generator.nova.Ext
import com.jetbrains.rd.generator.nova.property
import com.jetbrains.rd.generator.nova.PredefinedType.*
import com.jetbrains.rider.model.nova.ide.SolutionModel


@Suppress("unused")
object RiderDevExpressPluginModel : Ext(SolutionModel.Solution) {
    init {
        property("pluginTemplatesPath", string)
    }
}