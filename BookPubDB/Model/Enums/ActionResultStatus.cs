namespace BookPubDB.Model.Enums
{
    public enum ActionResultStatus
    {
        Ok = 200,
        Created = 201,
        Accepted = 202,
        NoContent = 204,
        Deleted = 231,
        Updated = 232,

        BadRequest = 400,
        Unauthorized = 401,
        Forbidden = 403,
        NotFound = 404,
        Conflict = 409,
        UnprocessableEntity = 422,

        InternalServerError = 500,
        NotImplemented = 501,
        BadGateway = 502,
        ServiceUnavailable = 503,
    }
}