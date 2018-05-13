import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';



@Injectable()

export class ComputerService {

    myAppUrl: string = "";

    constructor(private _http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.myAppUrl = baseUrl;
    }

    getComputer() {

        return this._http.get(this.myAppUrl + 'api/Computer/Index')
            .map((response: Response) => response.json())
            .catch(this.errorHandler);

    }

    getComputerById(id: number) {

        return this._http.get(this.myAppUrl + "api/Computer/Details/" + id)
            .map((response: Response) => response.json())
            .catch(this.errorHandler)

    }

    saveComputer(computer) {

        return this._http.post(this.myAppUrl + 'api/Computer/Create', computer)
            .map((response: Response) => response.json())
            .catch(this.errorHandler)

    }

    updateComputer(computer) {

        return this._http.put(this.myAppUrl + 'api/Computer/Edit', computer)
            .map((response: Response) => response.json())
            .catch(this.errorHandler);

    }

    deleteComputer(id) {

        return this._http.delete(this.myAppUrl + "api/Computer/Delete/" + id)
            .map((response: Response) => response.json())
            .catch(this.errorHandler);

    }

    errorHandler(error: Response) {

        console.log(error);
        return Observable.throw(error);

    }

}