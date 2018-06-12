pub mod point_attributes;

use std;
use std::vec::Vec;
use std::collections::BinaryHeap;
use std::cmp::Ordering;
pub use self::point_attributes::PointAttributes;

#[derive(Copy, Clone, Eq, PartialEq)]
pub struct PointQueueItem {
    priority: i32,
    indice: i32
}

impl Ord for PointQueueItem {
    fn cmp(&self, other: &PointQueueItem) -> Ordering {
        other.priority.cmp(&self.priority)
    }
}

impl PartialOrd for PointQueueItem {
    fn partial_cmp(&self, other: &PointQueueItem) -> Option<Ordering> {
        Some(self.cmp(other))
    }
}

fn get_neighbors(current_indice: i32, n_map_width: i32, n_map_height: i32) -> [i32; 4] {
    let x = current_indice % n_map_width;
    let y = current_indice / n_map_width;

    [
        if x > 0 { x - 1 + y * n_map_width } else { -1 },
        if x < (n_map_width - 1) { x + 1 + y * n_map_width } else { -1 },
        if y > 0 { x + (y - 1)  * n_map_width } else { -1 },
        if y < (n_map_height - 1) { x + (y + 1)  * n_map_width } else { -1 }
    ]
}

pub fn find_path(n_start_x: i32, n_start_y: i32, n_target_x: i32, n_target_y: i32, p_map: &[u8], n_map_width: i32, n_map_height: i32) -> (i32, std::vec::Vec<i32>, Vec<PointAttributes>) {
    let start = n_start_y * n_map_width + n_start_x;
    let end = n_target_y * n_map_width + n_target_x;

    let mut found_path = false;

    let mut point_attributes: Vec<_> = std::iter::repeat(PointAttributes::default()).take((n_map_width * n_map_height) as usize).collect();
    point_attributes.get_mut(start as usize).unwrap().cost_sum = 0;

    let mut frontier = BinaryHeap::new();
    frontier.push(PointQueueItem { priority: 0, indice: start });

    while let Some(current) = frontier.pop() {
        if current.indice == end {
            found_path = true;
            break;
        }

        let current_cost = point_attributes.get(current.indice as usize).unwrap().cost_sum;

        let neighbors = get_neighbors(current.indice, n_map_width, n_map_height);

        for neighbor in neighbors.iter().filter(|&&n| n != (-1) && *p_map.get(n as usize).unwrap() != 0) {
            let mut neighbor_attr = point_attributes.get_mut(*neighbor as usize).unwrap();
            if neighbor_attr.came_from != (-1) && neighbor_attr.cost_sum <= current_cost + 1 { continue; }

            neighbor_attr.came_from = current.indice;
            neighbor_attr.cost_sum = current_cost + 1;

            let x_cost = neighbor % n_map_width - end % n_map_width;
            let y_cost = neighbor / n_map_width - end / n_map_width;
            let cost = x_cost.abs() + y_cost.abs();
            frontier.push(PointQueueItem { indice: *neighbor, priority: cost + neighbor_attr.cost_sum });
        }
    }

    if !found_path { return (-1, std::vec::Vec::new(), std::vec::Vec::new()); }

    let (sum, p_out_buffer) = get_path(&point_attributes, start, end);

    (sum, p_out_buffer, point_attributes)
}

fn get_path(points: &Vec<PointAttributes>, start: i32, end: i32) -> (i32, Vec<i32>) {
    let mut current = points.get(end as usize).unwrap();
    let mut p_out_buffer = Vec::new();

    p_out_buffer.push(end);
    let sum = current.cost_sum;

    for _i in 0..sum {
        if current.came_from  == start { break }
        p_out_buffer.push(current.came_from);

        current = points.get(current.came_from as usize).unwrap();
    }

    p_out_buffer.reverse();

    (sum, p_out_buffer)
}

#[cfg(test)]
mod tests {
    use super::find_path;

    #[test]
    fn minimal() {
        let p_map: [u8; 3] = [1, 1, 1];
        let (res, _, _) = find_path(0, 0, 2, 0, &p_map, 3, 1);
        assert_eq!(2, res);
    }

    #[test]
    fn obstacle() {
        let p_map: [u8; 25] = [
            1, 1, 1, 1, 1,
            1, 1, 1, 1, 1,
            1, 0, 0, 0, 1,
            1, 1, 1, 1, 1,
            1, 1, 1, 1, 1,
        ];

        let (res, _, _) = find_path(2, 4, 2, 0, &p_map, 5, 5);
        assert_eq!(8, res);
    }

    #[test]
    fn enclosed() {
        let p_map: [u8; 30] = [
            1, 1, 1, 1, 1,
            1, 1, 1, 1, 1,
            1, 1, 0, 1, 1,
            1, 0, 1, 0, 1,
            1, 1, 0, 1, 1,
            1, 1, 1, 1, 1
        ];

        let (res, _, _) = find_path(2, 0, 2, 3, &p_map, 5, 6);
        assert_eq!(-1, res);
    }
}