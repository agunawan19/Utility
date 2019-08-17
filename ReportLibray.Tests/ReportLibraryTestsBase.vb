Imports Unity
Imports Moq
Imports UtilityLibraries

Public Class ReportLibraryTestsBase
    Private ReadOnly Property Container As IUnityContainer
    Public ReadOnly Property MockReportLibrary As Mock(Of IReportLibrary)
    Public ReadOnly Property ReportLibrary As IReportLibrary

    Public Sub New()
        Container = New UnityContainer()
        Container.RegisterInstance(GetType(Mock), New Mock(Of IUnityContainer))
        Container.RegisterType(Of IReportLibrary, ReportLibrary)()
        ReportLibrary = Container.Resolve(Of ReportLibrary)()
        MockReportLibrary = Container.Resolve(Of Mock(Of IReportLibrary))()
    End Sub

End Class
