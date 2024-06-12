const _apiUrl = "/api/storiesauthor";

export const getStoriesIncludingUser = (UserId) => {
  return fetch(_apiUrl + `/${UserId}`).then((response) => response.json());
};

export const getStoryAuthorByObject = (StoryAuthorObject) => {
  return fetch(
    `${_apiUrl}?UserId=${StoryAuthorObject.UserId}&StoryId=${StoryAuthorObject.StoryId}`
  ).then((res) => res.json());
};
