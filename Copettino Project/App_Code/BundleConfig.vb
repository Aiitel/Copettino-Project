﻿Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Optimization
Imports System.Web.UI

Public Module BundleConfig
    ' Per altre informazioni sulla creazione di bundle, vedere https://go.microsoft.com/fwlink/?LinkID=303951
    Public Sub RegisterBundles(bundles As BundleCollection)
        bundles.Add(New ScriptBundle("~/bundles/WebFormsJs").Include(
            "~/Scripts/WebForms/WebForms.js",
            "~/Scripts/WebForms/WebUIValidation.js",
            "~/Scripts/WebForms/MenuStandards.js",
            "~/Scripts/WebForms/Focus.js", "~/Scripts/WebForms/GridView.js", 
            "~/Scripts/WebForms/DetailsView.js",
            "~/Scripts/WebForms/TreeView.js",
            "~/Scripts/WebForms/WebParts.js"))

        ' L'ordine è molto importante per il funzionamento di questi file poiché hanno dipendenze esplicite
        bundles.Add(New ScriptBundle("~/bundles/MsAjaxJs").Include(
            "~/Scripts/WebForms/MsAjax/MicrosoftAjax.js",
            "~/Scripts/WebForms/MsAjax/MicrosoftAjaxApplicationServices.js",
            "~/Scripts/WebForms/MsAjax/MicrosoftAjaxTimer.js",
            "~/Scripts/WebForms/MsAjax/MicrosoftAjaxWebForms.js"))

        ' Utilizzare la versione di sviluppo di Modernizr per eseguire attività di sviluppo ed esercizi. Successivamente, quando si è
        ' pronti per passare alla produzione, usare lo strumento di compilazione disponibile all'indirizzo https://modernizr.com per selezionare solo i test necessari
        bundles.Add(New ScriptBundle("~/bundles/modernizr").Include(
            "~/Scripts/modernizr-*"))
    End Sub
End Module
