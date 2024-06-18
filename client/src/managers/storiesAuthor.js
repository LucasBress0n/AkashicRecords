const _apiUrl = "/api/storiesauthor";

export const getStoriesIncludingUser = (UserId) => {
  return fetch(_apiUrl + `/${UserId}`).then((response) => response.json());
};

export const getStoryAuthorByObject = (StoryAuthorObject) => {
  return fetch(
    `${_apiUrl}?UserId=${StoryAuthorObject.UserId}&StoryId=${StoryAuthorObject.StoryId}`
  ).then((res) => res.json());
};

export const getAllAuthorsForAStoryByStoryId = (StoryId) => {
  return fetch(`${_apiUrl}/${StoryId}/story`).then((res) => res.json());
};

export const getAllInvitesForAStoryByStoryId = (StoryId) => {
  return fetch(`${_apiUrl}/${StoryId}/invited`).then((res) => res.json());
};

export const createNewInvite = (InviteObject, UsersName) => {
  return fetch(_apiUrl + `?UsersNameSearched=${UsersName}`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(InviteObject),
  });
};

export const getAllInvitesBelongingToAUserByUserId = (UserId) => {
  return fetch(`${_apiUrl}/${UserId}/myinvites`).then((res) => res.json());
};

export const acceptInvite = (InviteObject) => {
  return fetch(`${_apiUrl}/accept`, {
    method: "PUT",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(InviteObject),
  });
};

export const declineInvite = (InviteObject) => {
  return fetch(`${_apiUrl}/decline`, {
    method: "DELETE",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(InviteObject),
  });
};
