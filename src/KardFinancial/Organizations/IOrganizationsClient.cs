using KardFinancial.Organizations;

namespace KardFinancial;

public partial interface IOrganizationsClient
{
    public IChildrenClient Children { get; }
    public IContentStrategiesClient ContentStrategies { get; }
    public IPlacementsClient Placements { get; }

    /// <summary>
    /// Retrieve organization details for the authenticated issuer
    /// </summary>
    WithRawResponseTask<ExternalOrganizationResponse> GetAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
