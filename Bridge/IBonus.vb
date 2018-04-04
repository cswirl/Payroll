
Public Interface IBonus

    Property ID() As UInteger



    Property empNum() As UInteger

    Property bonusTypeCode() As UInt16

    Property amount() As Double

    Property remark() As String



    Property isSettled() As Boolean

    Property dateCreated() As Date

    Property lastModifiedBy() As UInteger

    Property settledBy() As UInteger

    Property lastModified() As Date

    Property specify() As String

    Property dateSettled() As Date


End Interface