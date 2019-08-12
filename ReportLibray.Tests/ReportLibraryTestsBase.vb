Imports Unity
Imports Moq
Imports UtilityLibraries

Public Class ReportLibraryTestsBase
    Private ReadOnly Property Dependency As IUnityContainer
    Public ReadOnly Property MockReportLibrary As Mock(Of IReportLibrary)
    Public ReadOnly Property ReportLibrary As IReportLibrary

    Public Sub New()
        Dependency = New UnityContainer()
        Dependency.RegisterInstance(GetType(Mock), New Mock(Of IUnityContainer))
        Dependency.RegisterType(Of IReportLibrary, ReportLibrary)()
        ReportLibrary = Dependency.Resolve(Of ReportLibrary)()
        MockReportLibrary = Dependency.Resolve(Of Mock(Of IReportLibrary))()
    End Sub

End Class
