<?xml version="1.0" encoding="utf-8"?>
<configurationSectionModel xmlns:dm0="http://schemas.microsoft.com/VisualStudio/2008/DslTools/Core" dslVersion="1.0.0.0" Id="f8c4f2a4-f938-48ed-8447-70428dbe1498" namespace="SourcePro.Csharp.Practices.FoundationLibrary.Commons.Configuration" xmlSchemaNamespace="https://github.com/SourceproStudio" assemblyName="SourceProStudio.Practices.FoundationLibrary.Data" xmlns="http://schemas.microsoft.com/dsltools/ConfigurationSectionDesigner">
  <typeDefinitions>
    <externalType name="String" namespace="System" />
    <externalType name="Boolean" namespace="System" />
    <externalType name="Int32" namespace="System" />
    <externalType name="Int64" namespace="System" />
    <externalType name="Single" namespace="System" />
    <externalType name="Double" namespace="System" />
    <externalType name="DateTime" namespace="System" />
    <externalType name="TimeSpan" namespace="System" />
  </typeDefinitions>
  <configurationElements>
    <configurationElement name="DatabasePropertyProtectionElement" documentation="用于配置数据库属性保护器类型。">
      <attributeProperties>
        <attributeProperty name="Name" isRequired="true" isKey="true" isDefaultCollection="false" xmlName="name" isReadOnly="false" documentation="属性保护器名称。">
          <type>
            <externalTypeMoniker name="/f8c4f2a4-f938-48ed-8447-70428dbe1498/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="Type" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="type" isReadOnly="false" documentation="实现了IDatabasePropertyProtection接口的类型。">
          <type>
            <externalTypeMoniker name="/f8c4f2a4-f938-48ed-8447-70428dbe1498/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElementCollection name="DatabasePropertyProtectionElementCollection" inheritanceModifier="Sealed" documentation="DatabasePropertyProtectionElement集合。" collectionType="BasicMap" xmlItemName="add" codeGenOptions="Indexer, AddMethod, RemoveMethod">
      <itemType>
        <configurationElementMoniker name="/f8c4f2a4-f938-48ed-8447-70428dbe1498/DatabasePropertyProtectionElement" />
      </itemType>
    </configurationElementCollection>
    <configurationSection name="DatabasePropertyProtectionSection" documentation="数据库属性保护器配置。" codeGenOptions="XmlnsProperty" xmlSectionName="databaseProtections">
      <elementProperties>
        <elementProperty name="Protections" isRequired="false" isKey="false" isDefaultCollection="true" xmlName="" isReadOnly="false" documentation="数据库属性保护器配置。">
          <type>
            <configurationElementCollectionMoniker name="/f8c4f2a4-f938-48ed-8447-70428dbe1498/DatabasePropertyProtectionElementCollection" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationSection>
    <configurationElement name="DatabaseAccessProviderElement" documentation="用于配置数据库访问组件类型。">
      <attributeProperties>
        <attributeProperty name="Name" isRequired="true" isKey="true" isDefaultCollection="false" xmlName="name" isReadOnly="false" documentation="数据库访问组件名称。">
          <type>
            <externalTypeMoniker name="/f8c4f2a4-f938-48ed-8447-70428dbe1498/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="Type" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="type" isReadOnly="false" documentation="实现了IDatabase接口的类型。">
          <type>
            <externalTypeMoniker name="/f8c4f2a4-f938-48ed-8447-70428dbe1498/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElementCollection name="DatabaseAccessProviderElementCollection" inheritanceModifier="Sealed" documentation="DatabaseAccessProviderElement集合。" collectionType="BasicMap" xmlItemName="add" codeGenOptions="Indexer, AddMethod, RemoveMethod">
      <itemType>
        <configurationElementMoniker name="/f8c4f2a4-f938-48ed-8447-70428dbe1498/DatabaseAccessProviderElement" />
      </itemType>
    </configurationElementCollection>
    <configurationSection name="DatabaseAccessProviderSection" documentation="数据库访问组件配置。" codeGenOptions="Singleton" xmlSectionName="databaseProviders">
      <elementProperties>
        <elementProperty name="Providers" isRequired="false" isKey="false" isDefaultCollection="true" xmlName="" isReadOnly="false" documentation="数据库组件配置。">
          <type>
            <configurationElementCollectionMoniker name="/f8c4f2a4-f938-48ed-8447-70428dbe1498/DatabaseAccessProviderElementCollection" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationSection>
    <configurationElement name="IsProtectedDatabasePropertyElement" documentation="用于配置经过保护的数据库属性。">
      <attributeProperties>
        <attributeProperty name="PropertyName" isRequired="true" isKey="true" isDefaultCollection="false" xmlName="propertyName" isReadOnly="false" documentation="被保护的属性名称。">
          <type>
            <externalTypeMoniker name="/f8c4f2a4-f938-48ed-8447-70428dbe1498/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="ProtectedValue" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="protectedValue" isReadOnly="false" documentation="经过保护的属性值。">
          <type>
            <externalTypeMoniker name="/f8c4f2a4-f938-48ed-8447-70428dbe1498/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="ProtectionName" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="protectionName" isReadOnly="false" documentation="属性保护器名称。">
          <type>
            <externalTypeMoniker name="/f8c4f2a4-f938-48ed-8447-70428dbe1498/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElementCollection name="IsProtectedDatabasePropertyElementCollection" inheritanceModifier="Sealed" documentation="IsProtectedDatabasePropertyElement集合。" collectionType="BasicMap" xmlItemName="add" codeGenOptions="Indexer, AddMethod, RemoveMethod">
      <itemType>
        <configurationElementMoniker name="/f8c4f2a4-f938-48ed-8447-70428dbe1498/IsProtectedDatabasePropertyElement" />
      </itemType>
    </configurationElementCollection>
    <configurationElement name="DatabaseConnectionElement" documentation="数据库连接配置。">
      <attributeProperties>
        <attributeProperty name="Name" isRequired="true" isKey="true" isDefaultCollection="false" xmlName="name" isReadOnly="false" documentation="数据库名称。">
          <type>
            <externalTypeMoniker name="/f8c4f2a4-f938-48ed-8447-70428dbe1498/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="ConnectionString" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="connectionString" isReadOnly="false" documentation="数据库连接串。">
          <type>
            <externalTypeMoniker name="/f8c4f2a4-f938-48ed-8447-70428dbe1498/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="DefaultSechema" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="defaultSechema" isReadOnly="false" documentation="默认架构名称。" defaultValue="&quot;dbo&quot;">
          <type>
            <externalTypeMoniker name="/f8c4f2a4-f938-48ed-8447-70428dbe1498/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="CommandTimeoutSeconds" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="commandTimeoutSeconds" isReadOnly="false" documentation="数据库命令执行超时秒数。" defaultValue="0">
          <type>
            <externalTypeMoniker name="/f8c4f2a4-f938-48ed-8447-70428dbe1498/Int32" />
          </type>
        </attributeProperty>
        <attributeProperty name="Provider" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="provider" isReadOnly="false" documentation="数据库访问器名称。">
          <type>
            <externalTypeMoniker name="/f8c4f2a4-f938-48ed-8447-70428dbe1498/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
      <elementProperties>
        <elementProperty name="Protections" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="protections" isReadOnly="false" documentation="需要保护的数据库属性。">
          <type>
            <configurationElementCollectionMoniker name="/f8c4f2a4-f938-48ed-8447-70428dbe1498/IsProtectedDatabasePropertyElementCollection" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationElement>
    <configurationElementCollection name="DatabaseConnectionElementCollection" inheritanceModifier="Sealed" documentation="DatabaseConnectionElement集合。" collectionType="BasicMap" xmlItemName="add" codeGenOptions="Indexer, AddMethod, RemoveMethod">
      <itemType>
        <configurationElementMoniker name="/f8c4f2a4-f938-48ed-8447-70428dbe1498/DatabaseConnectionElement" />
      </itemType>
    </configurationElementCollection>
    <configurationSection name="DatabaseConnectionSection" documentation="数据库连接配置。" codeGenOptions="Singleton" xmlSectionName="databaseConnections">
      <elementProperties>
        <elementProperty name="Connections" isRequired="false" isKey="false" isDefaultCollection="true" xmlName="" isReadOnly="false" documentation="数据库连接配置。">
          <type>
            <configurationElementCollectionMoniker name="/f8c4f2a4-f938-48ed-8447-70428dbe1498/DatabaseConnectionElementCollection" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationSection>
    <configurationSection name="DefaultDatabaseOptionsSection" documentation="数据库默认选项配置。" codeGenOptions="XmlnsProperty" xmlSectionName="defaultOptions">
      <attributeProperties>
        <attributeProperty name="DefaultDatabaseConnection" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="defaultDatabaseConnection" isReadOnly="false" documentation="默认的数据库连接名称。">
          <type>
            <externalTypeMoniker name="/f8c4f2a4-f938-48ed-8447-70428dbe1498/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="DefaultDatabaseProvider" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="defaultDatabaseProvider" isReadOnly="false" documentation="默认的数据库访问器。">
          <type>
            <externalTypeMoniker name="/f8c4f2a4-f938-48ed-8447-70428dbe1498/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="DefaultDatabaseProtection" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="defaultDatabaseProtection" isReadOnly="false" documentation="默认的数据库属性保护器。">
          <type>
            <externalTypeMoniker name="/f8c4f2a4-f938-48ed-8447-70428dbe1498/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationSection>
    <configurationSectionGroup name="sourcepro.data">
      <configurationSectionProperties>
        <configurationSectionProperty>
          <containedConfigurationSection>
            <configurationSectionMoniker name="/f8c4f2a4-f938-48ed-8447-70428dbe1498/DefaultDatabaseOptionsSection" />
          </containedConfigurationSection>
        </configurationSectionProperty>
        <configurationSectionProperty>
          <containedConfigurationSection>
            <configurationSectionMoniker name="/f8c4f2a4-f938-48ed-8447-70428dbe1498/DatabaseConnectionSection" />
          </containedConfigurationSection>
        </configurationSectionProperty>
        <configurationSectionProperty>
          <containedConfigurationSection>
            <configurationSectionMoniker name="/f8c4f2a4-f938-48ed-8447-70428dbe1498/DatabasePropertyProtectionSection" />
          </containedConfigurationSection>
        </configurationSectionProperty>
        <configurationSectionProperty>
          <containedConfigurationSection>
            <configurationSectionMoniker name="/f8c4f2a4-f938-48ed-8447-70428dbe1498/DatabaseAccessProviderSection" />
          </containedConfigurationSection>
        </configurationSectionProperty>
      </configurationSectionProperties>
    </configurationSectionGroup>
  </configurationElements>
  <propertyValidators>
    <validators />
  </propertyValidators>
</configurationSectionModel>