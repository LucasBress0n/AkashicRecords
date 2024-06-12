const _apiUrl = "/api/storiesauthor";

export const getStoriesIncludingUser = (UserId) => {
  return fetch(_apiUrl + `/${UserId}`).then((response) => response.json());
};
