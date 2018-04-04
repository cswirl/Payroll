Public Class WizardPrimeForm

    'StateOriented
    Protected Overrides Sub addingState()

    End Sub

    Protected Overrides Sub addingState_DefaultControls()

    End Sub

    Protected Overrides Sub addingSuccess()

    End Sub

    Protected Overrides Sub addNewPrime()

    End Sub

    Protected Overrides Sub bindMyControls()

    End Sub

    Protected Overrides Function getBoundSource_PKey() As UInteger

    End Function

    Protected Overrides Sub idleState()

    End Sub

    Protected Overrides Sub initializeMyComponent()

    End Sub

    Protected Overrides Sub initializeControls()

    End Sub

    Protected Overrides Sub modifyingState()

    End Sub

    Protected Overrides Sub modifyingSuccess()

    End Sub

    Protected Overrides Sub positionChanged()

    End Sub

    Protected Overrides Sub representPrimeInfo()

    End Sub

    Protected Overrides Sub updatePrime()

    End Sub


    'Wizard Oriented
    Protected Overrides Function canStepForward() As Boolean

        Return True
    End Function

    Protected Overrides Sub initializeMyWizard(ByVal ParamArray steps() As String)

    End Sub

End Class