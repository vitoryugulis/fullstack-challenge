import { Person } from './person.model';

export interface Species{
    name: string;
    homeworld: string
    persons: Person[];
}