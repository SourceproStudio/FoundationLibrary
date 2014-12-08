<?xml version="1.0" encoding="utf-8"?>
<configurationSectionModel xmlns:dm0="http://schemas.microsoft.com/VisualStudio/2008/DslTools/Core" dslVersion="1.0.0.0" Id="b71fc659-0b10-49a6-8381-e4860a99f4cd" namespace="SourcePro.Csharp.Practices.FoundationLibrary.Commons.Configuration" xmlSchemaNamespace="https://github.com/SourceproStudio" assemblyName="SourceProStudio.Practices.FoundationLibrary.Commons.Configuration" xmlns="http://schemas.microsoft.com/dsltools/ConfigurationSectionDesigner">
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
    <configurationElement name="ConfigurationSourceElement" documentation="用于配置ConfigurationSection的源。">
      <attributeProperties>
        <attributeProperty name="Name" isRequired="true" isKey="true" isDefaultCollection="false" xmlName="sectionName" isReadOnly="false" documentation="自定义ConfigurationSection的标识名称。">
          <type>
            <externalTypeMoniker name="/b71fc659-0b10-49a6-8381-e4860a99f4cd/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="Path" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="sourcePath" isReadOnly="false" documentation="配置源文件路径。">
          <type>
            <externalTypeMoniker name="/b71fc659-0b10-49a6-8381-e4860a99f4cd/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElementCollection name="ConfigurationSourceElementCollection" inheritanceModifier="Sealed" documentation="ConfigurationSourceElement集合。" collectionType="BasicMap" xmlItemName="add" codeGenOptions="Indexer, AddMethod, RemoveMethod">
      <itemType>
        <configurationElementMoniker name="/b71fc659-0b10-49a6-8381-e4860a99f4cd/ConfigurationSourceElement" />
      </itemType>
    </configurationElementCollection>
    <configurationSection name="ConfigurationSourceSection" documentation="用于配置ConfigurationSection的源文件信息。" codeGenOptions="XmlnsProperty" xmlSectionName="sourcepro.configurationSource">
      <elementProperties>
        <elementProperty name="Sources" isRequired="false" isKey="false" isDefaultCollection="true" xmlName="" isReadOnly="false" documentation="ConfigurationSourceElementCollection配置。">
          <type>
            <configurationElementCollectionMoniker name="/b71fc659-0b10-49a6-8381-e4860a99f4cd/ConfigurationSourceElementCollection" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationSection>
  </configurationElements>
  <propertyValidators>
    <validators />
  </propertyValidators>
</configurationSectionModel>