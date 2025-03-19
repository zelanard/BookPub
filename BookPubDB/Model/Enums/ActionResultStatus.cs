using static System.Formats.Asn1.AsnWriter;

namespace BookPubDB.Model.Enums
{
    /// <include file='Documentation/Model/Enums/ActionResultStatus.xml' path='doc/actionresultstatus/member[@name="E:BookPubDB.Model.Enums.ActionResultStatus"]' />
    public enum ActionResultStatus
    {
        /// <include file='Documentation/Model/Enums/ActionResultStatus.xml' path='doc/actionresultstatus/member[@name="F:BookPubDB.Model.Enums.ActionResultStatus.Ok"]' />
        Ok = 200,
        /// <include file='Documentation/Model/Enums/ActionResultStatus.xml' path='doc/actionresultstatus/member[@name="F:BookPubDB.Model.Enums.ActionResultStatus.Created"]' />
        Created = 201,
        /// <include file='Documentation/Model/Enums/ActionResultStatus.xml' path='doc/actionresultstatus/member[@name="F:BookPubDB.Model.Enums.ActionResultStatus.Accepted"]' />
        Accepted = 202,
        /// <include file='Documentation/Model/Enums/ActionResultStatus.xml' path='doc/actionresultstatus/member[@name="F:BookPubDB.Model.Enums.ActionResultStatus.NoContent"]' />
        NoContent = 204,
        /// <include file='Documentation/Model/Enums/ActionResultStatus.xml' path='doc/actionresultstatus/member[@name="F:BookPubDB.Model.Enums.ActionResultStatus.Deleted"]' />
        Deleted = 231,
        /// <include file='Documentation/Model/Enums/ActionResultStatus.xml' path='doc/actionresultstatus/member[@name="F:BookPubDB.Model.Enums.ActionResultStatus.Updated"]' />
        Updated = 232,

        /// <include file='Documentation/Model/Enums/ActionResultStatus.xml' path='doc/actionresultstatus/member[@name="F:BookPubDB.Model.Enums.ActionResultStatus.BadRequest"]' />
        BadRequest = 400,
        /// <include file='Documentation/Model/Enums/ActionResultStatus.xml' path='doc/actionresultstatus/member[@name="F:BookPubDB.Model.Enums.ActionResultStatus.Unauthorized"]' />
        Unauthorized = 401,
        /// <include file='Documentation/Model/Enums/ActionResultStatus.xml' path='doc/actionresultstatus/member[@name="F:BookPubDB.Model.Enums.ActionResultStatus.Forbidden"]' />
        Forbidden = 403,
        /// <include file='Documentation/Model/Enums/ActionResultStatus.xml' path='doc/actionresultstatus/member[@name="F:BookPubDB.Model.Enums.ActionResultStatus.NotFound"]' />
        NotFound = 404,
        /// <include file='Documentation/Model/Enums/ActionResultStatus.xml' path='doc/actionresultstatus/member[@name="F:BookPubDB.Model.Enums.ActionResultStatus.Conflict"]' />
        Conflict = 409,
        /// <include file='Documentation/Model/Enums/ActionResultStatus.xml' path='doc/actionresultstatus/member[@name="F:BookPubDB.Model.Enums.ActionResultStatus.UnprocessableEntity"]' />
        UnprocessableEntity = 422,

        /// <include file='Documentation/Model/Enums/ActionResultStatus.xml' path='doc/actionresultstatus/member[@name="F:BookPubDB.Model.Enums.ActionResultStatus.InternalServerError"]' />
        InternalServerError = 500,
        /// <include file='Documentation/Model/Enums/ActionResultStatus.xml' path='doc/actionresultstatus/member[@name="F:BookPubDB.Model.Enums.ActionResultStatus.NotImplemented"]' />
        NotImplemented = 501,
        /// <include file='Documentation/Model/Enums/ActionResultStatus.xml' path='doc/actionresultstatus/member[@name="F:BookPubDB.Model.Enums.ActionResultStatus.BadGateway"]' />
        BadGateway = 502,
        /// <include file='Documentation/Model/Enums/ActionResultStatus.xml' path='doc/actionresultstatus/member[@name="F:BookPubDB.Model.Enums.ActionResultStatus.ServiceUnavailable"]' />
        ServiceUnavailable = 503,
    }
}

