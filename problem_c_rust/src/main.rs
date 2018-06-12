extern crate chrono;

mod pathfinder;
mod map_description;

use pathfinder::point_attributes::PointAttributes;
use std::fs::File;
use chrono::prelude::*;
use std::io::prelude::*;

fn read_map() -> map_description::MapDescription {
    let path = std::path::Path::new("sample.in");
    println!("{:?}", path);
    let mut file = File::open(path).expect("Error reading file");
    let mut contents = String::new();
    let mut start: i32 = -1;
    let mut end: i32 = -1;
    file.read_to_string(&mut contents).expect("Failed to read to string");
    let width = (contents.chars().position(|c| c == '\n').expect("Unable to calculate width of map") - 1) as i32;

    let p_map: Vec<u8> = contents
        .chars()
        .filter(|c| "10SE".contains(*c))
        .enumerate()
        .map(|(i, c)| {
            if c == 'S' { start = i as i32 }
            if c == 'E' { end = i as i32 }
            match c {
                '0' => 0,
                _ => 1
            }
        } )
        .collect();

    if start == -1 || end == -1 { panic!("Unable to find start and end") }
    map_description::MapDescription {
        end,
        start,
        height: (p_map.len() as i32 / width),
        map: p_map,
        width,
    }
}

fn draw_map(p_map: &[u8], points: &[PointAttributes], height: i32, width: i32, start: i32, end: i32) {
    for y in 0..height {
        for x in 0..width {
            let indice = (y * width + x) as usize;
            let point = &points[indice];
            if start == indice as i32 { print!("S") }
            else if end == indice as i32 { print!("E") }
            else if p_map[indice] == 41 { print!("*") }
            else if p_map[indice] == 0 { print!("@") }
            else if point.came_from != -1 { print!("%") }
            else if p_map[indice] == 1 { print!(" ") }
        }
        println!();
    }
}

fn main() {
    let mut map = read_map();
    println!("{:?}", map.width);
    let t1 = Utc::now();
    let (cost, path, points) = pathfinder::find_path(map.start % map.width, map.start / map.width, map.end % map.width, map.end / map.width, &map.map, map.width, map.height);

    let t2 = Utc::now() - t1;
    println!("Steps: {:?}, Nanoseconds: {:?}", cost, t2.num_nanoseconds().expect("Somehow failed to get the time"));
    if cost == -1 {
        panic!("Found no path");
    }

    for i in 0..cost {
        map.map[path[i as usize] as usize] = 41;
    }

    draw_map(&map.map, &points, map.height, map.width, map.start, map.end);
}
