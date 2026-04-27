using KardApi.Users;

namespace KardApi;

public partial interface IUsersClient
{
    public IAttributionsClient Attributions { get; }
    public KardApi.Users.IAuthClient Auth { get; }
    public IRewardsClient Rewards { get; }
    public IUploadsClient Uploads { get; }

    /// <summary>
    /// Call this endpoint to enroll a specified user into your rewards program.<br/>
    ///
    /// <b>Required scopes:</b>  `user:write`<br/>
    /// <b>Note:</b> `Maximum of 100 users can be created per request`.
    /// </summary>
    WithRawResponseTask<CreateUsersObject> CreateAsync(
        string organizationId,
        CreateUsersObject request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Call this endpoint to update the details on a specified user.<br/>
    ///
    /// <b>Required scopes:</b> `user:update`
    /// </summary>
    WithRawResponseTask<UserResponseObject> UpdateAsync(
        string organizationId,
        string userId,
        UpdateUserObject request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Call this endpoint to delete a specified enrolled user from the rewards program and Kard's system. Users can be re-enrolled into rewards by calling the [Create User](/2024-10-01/api/users/create) endpoint using the same `id` from before.<br/>
    ///
    /// <b>Required scopes:</b> `user:delete`
    /// </summary>
    WithRawResponseTask<DeleteUserResponseObject> DeleteAsync(
        string organizationId,
        string userId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Call this endpoint to fetch the details on a specified user.<br/>
    /// <br/>
    /// <b>Required scopes:</b>  `user:read`
    /// </summary>
    WithRawResponseTask<UserResponseObject> GetAsync(
        string organizationId,
        string userId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
