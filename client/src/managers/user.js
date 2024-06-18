const _apiUrl = "/api/user";

export const getUserWithStoriesById = (UserId) => {
  return fetch(_apiUrl + `/${UserId}`).then((r) => r.json());
};
