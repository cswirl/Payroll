
Public Interface IUser

    Property user_ID() As UInteger

    Property empNum() As UInteger

    Property userName() As String

    Property userPassword() As String

    Property userTypeCode() As UInt16

    ''' <summary>
    ''' A value of 'True' if active
    ''' </summary>
    Property active() As Boolean

    Property dateCreated() As Date

    Property lastModified() As Date

    Property lastModifiedBy() As UInteger

End Interface