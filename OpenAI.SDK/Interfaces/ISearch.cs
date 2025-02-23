﻿using OpenAI.GPT3.Models;
using OpenAI.GPT3.Models.RequestModels;
using OpenAI.GPT3.Models.ResponseModels;

namespace OpenAI.GPT3.Interfaces;

/// <summary>
///     Given a query and a set of documents or labels, the model ranks each document based on its semantic similarity to
///     the provided query.
///     Related guide: <a href="https://beta.openai.com/docs/guides/search">Search</a>
/// </summary>
public interface ISearch
{
    /// <summary>
    ///     The search endpoint computes similarity scores between provided query and documents. Documents can be passed
    ///     directly to the API if there are no more than 200 of them.
    ///     To go beyond the 200 document limit, documents can be processed offline and then used for efficient retrieval at
    ///     query time.When file is set, the search endpoint searches over all the documents in the given file and returns up
    ///     to the max_rerank number of documents.These documents will be returned along with their search scores.
    ///     The similarity score is a positive score that usually ranges from 0 to 300 (but can sometimes go higher), where a
    ///     score above 200 usually means the document is semantically similar to the query.
    /// </summary>
    /// <param name="engineId">The ID of the engine to use for this request</param>
    /// <param name="createSearchRequest"></param>
    /// <returns></returns>
    Task<SearchCreateResponse> SearchCreate(SearchCreateRequest createSearchRequest, string? engineId = null);

    Task<SearchCreateResponse> SearchCreate(SearchCreateRequest createSearchRequest, Engines.Engine engineId)
    {
        return SearchCreate(createSearchRequest, engineId.EnumToString());
    }
}