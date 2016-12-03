import { fetch } from "../utilities";
import { UserSettings } from "./user-settings.model";

export class UserSettingsService {
    
    private static _instance: UserSettingsService;

    public static get Instance() {
        this._instance = this._instance || new UserSettingsService();
        return this._instance;
    }

    public get() {
        return fetch({ url: "/api/user-settings/get" });
    }

    public getById(id) {
        return fetch({ url: `/api/user-settings/getbyid?id=${id}`, authRequired: true });
    }

    public add(entity) {
        return fetch({ url: `/api/user-settings/add`, method: "POST", data: entity, authRequired: true  });
    }

    public remove(options: { id : number }) {
        return fetch({ url: `/api/user-settings/remove?id=${options.id}`, method: "DELETE", authRequired: true  });
    }
    
}
