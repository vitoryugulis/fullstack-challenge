import { Species } from './species.model';

export interface PaginatedSpecies{
    totalResults: number;
    species: Species[];
}