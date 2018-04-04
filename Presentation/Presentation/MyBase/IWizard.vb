Public Interface IWizard
    Sub addSteps(ByVal ParamArray steps() As String)
    Sub stepForward(ByVal sender As Object, ByVal e As EventArgs)
    Sub stepBackWard()
    Function getCurrentStep() As Integer
    Function getCurrentStepToString() As String
    'Revert the wizard to initial/default state
    Sub cancelWizardOperation()
End Interface
