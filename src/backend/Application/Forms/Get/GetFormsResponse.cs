using System.Collections.Generic;

namespace Application.Forms.Get;

public sealed class GetFormsResponse : List<GetFormModel>;

public sealed record GetFormModel(int FormId, string Title, string Subtitle, string Color);