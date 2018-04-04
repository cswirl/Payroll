'THIS FORM ONLY CREATED TO LEVERAGE THE DESIGN TIME FUNCTIONALITY OF VISUAL STUDIO
'BECAUSE AN ABSTRACT CLASSES CANNOT CREATE AN INSTANCE WHICH IS USED BY THE VS DESIGNER
Public Class PrimaryForm
    'State sub
    Protected Overrides Sub idleState()
    End Sub
    Protected Overrides Sub addingState()
    End Sub

    Protected Overrides Sub modifyingState()
    End Sub

    'Methods use while changing state
    Protected Overrides Sub initializeMyComponent()
    End Sub

    Protected Overrides Sub initializeControls()
    End Sub

    Protected Overrides Sub bindMyControls()
    End Sub

    Protected Overrides Sub addingState_DefaultControls()
    End Sub

    Protected Overrides Sub positionChanged()
    End Sub

    Protected Overrides Sub addNewPrime()
    End Sub

    Protected Overrides Sub updatePrime()
    End Sub

    Protected Overrides Sub representPrimeInfo()
    End Sub

    Protected Overrides Sub addingSuccess()
    End Sub

    Protected Overrides Sub modifyingSuccess()
    End Sub

    Protected Overrides Function getBoundSource_PKey() As UInteger
    End Function

End Class