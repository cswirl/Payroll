Imports CrossCutting

Public MustInherit Class ManagerBase
    ''All managers can use this for inspecting data before passing on to the data access layer
    'Insert
    Protected Overridable Sub insert_inspectData()
        Try
            insert_validateData()
            insert_checkRequiredData()
        Catch bex As BusinessException
            Throw bex
        End Try
    End Sub
    Protected MustOverride Sub insert_validateData()
    Protected MustOverride Sub insert_checkRequiredData()

    'Update
    Protected Overridable Sub update_inspectData()
        Try
            update_validateData()
            update_checkRequiredData()
        Catch bex As BusinessException
            Throw bex
        End Try
    End Sub
    Protected MustOverride Sub update_validateData()
    Protected MustOverride Sub update_checkRequiredData()

End Class