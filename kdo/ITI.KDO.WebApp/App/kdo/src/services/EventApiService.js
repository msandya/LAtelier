import { getAsync, postAsync, putAsync, deleteAsync } from '../helpers/apiHelper';

const endpoint = "/api/event";

class EventApiService{
    constructor(){

    }

    async getEventListAsync(userId){
        return await getAsync(`${endpoint}/${userId}/getEventByUserId`);
    }

    async getEventAsync(eventId){
        return await getAsync(`${endpoint}/${eventId}`);
    }

    async createEventAsync(model){
        return await postAsync(endpoint, model);
    }

    async updateEventAsync(model){
        return await putAsync(`${endpoint}/${model.eventId}`, model)
    }

    async deleteEventAsync(eventId) {
        return await deleteAsync(`${endpoint}/${eventId}`);
    }
}

export default new EventApiService()