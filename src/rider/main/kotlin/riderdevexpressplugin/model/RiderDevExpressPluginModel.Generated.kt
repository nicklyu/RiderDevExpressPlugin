@file:Suppress("PackageDirectoryMismatch", "UnusedImport", "unused", "LocalVariableName")
package com.jetbrains.rider.model

import com.jetbrains.rd.framework.*
import com.jetbrains.rd.framework.base.*
import com.jetbrains.rd.framework.impl.*

import com.jetbrains.rd.util.lifetime.*
import com.jetbrains.rd.util.reactive.*
import com.jetbrains.rd.util.string.*
import com.jetbrains.rd.util.*
import kotlin.reflect.KClass



class RiderDevExpressPluginModel private constructor(
    private val _pluginTemplatesPath: RdOptionalProperty<String>
) : RdExtBase() {
    //companion
    
    companion object : ISerializersOwner {
        
        override fun registerSerializersCore(serializers: ISerializers) {
        }
        
        
        
        
        const val serializationHash = -267406047508532528L
    }
    override val serializersOwner: ISerializersOwner get() = RiderDevExpressPluginModel
    override val serializationHash: Long get() = RiderDevExpressPluginModel.serializationHash
    
    //fields
    val pluginTemplatesPath: IOptProperty<String> get() = _pluginTemplatesPath
    //initializer
    init {
        _pluginTemplatesPath.optimizeNested = true
    }
    
    init {
        bindableChildren.add("pluginTemplatesPath" to _pluginTemplatesPath)
    }
    
    //secondary constructor
    internal constructor(
    ) : this(
        RdOptionalProperty<String>(FrameworkMarshallers.String)
    )
    
    //equals trait
    //hash code trait
    //pretty print
    override fun print(printer: PrettyPrinter) {
        printer.println("RiderDevExpressPluginModel (")
        printer.indent {
            print("pluginTemplatesPath = "); _pluginTemplatesPath.print(printer); println()
        }
        printer.print(")")
    }
}
val Solution.riderDevExpressPluginModel get() = getOrCreateExtension("riderDevExpressPluginModel", ::RiderDevExpressPluginModel)

